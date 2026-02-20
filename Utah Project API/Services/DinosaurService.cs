using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Utah_Project_API.Data;
using Utah_Project_API.DTO.Dinosaur;
using Utah_Project_API.Exceptions;
using Utah_Project_API.Interfaces;
using Utah_Project_API.Models;
using Utah_Project_API.Models.Dinosaur;
using Image = SixLabors.ImageSharp.Image;
using Rectangle = SixLabors.ImageSharp.Rectangle;
using Utah_Project_API.Enums;

namespace Utah_Project_API.Services;

public class DinosaurService(
    ApplicationDbContext context, 
    UserManager<User> userManager
    ) : IDinosaurService
{
    public async Task<List<Dinosaur>> GetAllDinosaurs()
    {
        List<Dinosaur> dinosaurs = await context.Dinosaurs.ToListAsync();
        
        return dinosaurs;
    }

    public async Task<Dinosaur> GetDinosaurById(int dinoCode)
    {
        Dinosaur? dinosaur = await context.Dinosaurs.FirstOrDefaultAsync(d => d.DinoCode == dinoCode);
        if (dinosaur == null)
        {
            throw new NotFoundException("Dinosaur not found");
        }

        return dinosaur;
    }

    public async Task<List<Dinosaur>> GetAllDinosaursUser(ClaimsPrincipal user)
    {
        var dinosaur = await context.Dinosaurs.Where(d => d.UserId == user
                .FindFirstValue(ClaimTypes.NameIdentifier))
            .ToListAsync();
        
        if (dinosaur == null || !dinosaur.Any())
        {
            throw new NotFoundException("No dinosaurs found for this user");
        }
        
        return dinosaur;
    }

    public async Task<Dinosaur> CreateDinosaur(DinosaurDto dinosaurData, ClaimsPrincipal user)
    {
        User? currentUser = await userManager.GetUserAsync(user);
        
        if (currentUser == null)
        {
            throw new NotFoundException("User not found");
        }
        
        if (!string.IsNullOrEmpty(dinosaurData.Picture) && dinosaurData.Picture.StartsWith("data:image"))
        {
            try
            {
                string uploadsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                Directory.CreateDirectory(uploadsDir);

                string base64Data = dinosaurData.Picture.Contains(',')
                    ? dinosaurData.Picture[(dinosaurData.Picture.IndexOf(',') + 1)..]
                    : dinosaurData.Picture;

                byte[] bytes = Convert.FromBase64String(base64Data);
                string fileName = $"{Guid.NewGuid()}.png";
                string filePath = Path.Combine(uploadsDir, fileName);

                using (Image image = Image.Load(bytes))
                {
                    const int targetSize = 800;

                    double scale = Math.Max(
                        (double)targetSize / image.Width,
                        (double)targetSize / image.Height
                    );

                    int resizedWidth = (int)(image.Width * scale);
                    int resizedHeight = (int)(image.Height * scale);

                    image.Mutate(x => x.Resize(resizedWidth, resizedHeight));

                    int cropX = (resizedWidth - targetSize) / 2;
                    int cropY = (resizedHeight - targetSize) / 2;

                    Rectangle cropRect = new(cropX, cropY, targetSize, targetSize);

                    image.Mutate(x => x.Crop(cropRect));

                    await image.SaveAsPngAsync(filePath);
                }

                dinosaurData.Picture = $"/uploads/{fileName}";
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to process image", ex);
            }
        }
        
        Dinosaur newDinosaur = new()
        {
            UserId = currentUser.Id,
            DinoName = dinosaurData.DinoName,
            Color = dinosaurData.Color,
            SpeciesId = dinosaurData.SpeciesId,
            Picture = dinosaurData.Picture,
            Gender = dinosaurData.gender
        };

        context.Dinosaurs.Add(newDinosaur);
        await context.SaveChangesAsync();

        return newDinosaur;
    }

    public async Task<Dinosaur> PatchDinosaur(int dinoCode, JsonPatchDocument<UpdateDinosaurDto> patchDoc)
    {
        Dinosaur? dinosaur = await context.Dinosaurs.FirstOrDefaultAsync(d => d.DinoCode == dinoCode);
        
        if (dinosaur == null)
        {
            throw new NotFoundException("Dinosaur not found");
        }

        UpdateDinosaurDto dto = new()
        {
            DinoName = dinosaur.DinoName,
            Color = dinosaur.Color,
            SpeciesId = dinosaur.SpeciesId,
            Picture = dinosaur.Picture,
            gender = dinosaur.Gender

        };
        
        patchDoc.ApplyTo(dto);
        
        // Map patched DTO back to entity
        dinosaur.DinoName = dto.DinoName;
        dinosaur.Color = dto.Color;
        dinosaur.SpeciesId = dto.SpeciesId;
        dinosaur.Picture = dto.Picture;
        dinosaur.Gender = (Gender)
            
        await context.SaveChangesAsync();
        return dinosaur;
    }

    public async Task<Dinosaur> DeleteDinosaur(ClaimsPrincipal user, int dinoCode)
    {
        Dinosaur? dinosaur = await context.Dinosaurs.FirstOrDefaultAsync(d => d.DinoCode == dinoCode);
        if (dinosaur == null)
        {
            throw new NotFoundException("Dinosaur not found");
        }

        if (dinosaur.UserId != user.FindFirstValue(ClaimTypes.NameIdentifier))
        {
            throw new UnauthorizedAccessException("You do not have permission to delete this dinosaur");
        }

        context.Dinosaurs.Remove(dinosaur);
        await context.SaveChangesAsync();

        return dinosaur;
    }

    public async Task<Dinosaur> AddBehaviourToDinosaur(int dinoCode, string behaviourCode)
    {
        Dinosaur? dinosaur = await context.Dinosaurs.FirstOrDefaultAsync(d => d.DinoCode == dinoCode);
        if (dinosaur == null)
        {
            throw new NotFoundException("Dinosaur not found");
        }
        
        Dino_Behaviour? behaviour = await context.DinoBehaviours.FirstOrDefaultAsync(db =>
            db.DinoCode == dinoCode && db.BehaviourCode == behaviourCode);
        
        if (behaviour == null)
        {
            throw new NotFoundException("Behaviour not found");
        }
        dinosaur.DinoBehaviours.Add(behaviour);
        await context.SaveChangesAsync();
        
        return dinosaur;
    }

    public async Task<Dinosaur> RemoveBehaviourFromDinosaur(int dinoCode, int behaviourId)
    {
        Dinosaur? dinosaur = await context.Dinosaurs.FirstOrDefaultAsync(d => d.DinoCode == dinoCode);
        if (dinosaur == null)
        {
            throw new NotFoundException("Dinosaur not found");
        }
        
        Dino_Behaviour? behaviour = await context.DinoBehaviours.FirstOrDefaultAsync(db =>
            db.DinoCode == dinoCode && db.BehaviourCode == behaviourId.ToString());
        
        if (behaviour == null)
        {
            throw new NotFoundException("Behaviour not found");
        }
        dinosaur.DinoBehaviours.Remove(behaviour);
        await context.SaveChangesAsync();
        
        return dinosaur;
    }

    public async Task<Dinosaur> AddNestToDinosaur(int dinoCode, int nestingId)
    {
        Dinosaur? dinosaur = await context.Dinosaurs.FirstOrDefaultAsync(d => d.DinoCode == dinoCode);
        if (dinosaur == null)
        {
            throw new NotFoundException("Dinosaur not found");
        }
        
        Dino_Nesting? nest = await context.DinoNestings.FirstOrDefaultAsync(db =>
            db.DinoCode == dinoCode && db.NestingId == nestingId);
        if (nest == null)
        {
            throw new NotFoundException("Nest not found");
        }
        
        dinosaur.NestId = nestingId;
        
        await context.SaveChangesAsync();
        
        return dinosaur;
    }

    public async Task<Dinosaur> RemoveNestFromDinosaur(int dinoCode, int nestingId)
    {
        Dinosaur? dinosaur = await context.Dinosaurs.FirstOrDefaultAsync(d => d.DinoCode == dinoCode);
        if (dinosaur == null)
        {
            throw new NotFoundException("Dinosaur not found");
        }
        
        Dino_Nesting? nest = await context.DinoNestings.FirstOrDefaultAsync(db =>
            db.DinoCode == dinoCode && db.NestingId == nestingId);
        if (nest == null)
        {
            throw new NotFoundException("Nest not found");
        }
        
        dinosaur.NestId = null;
        
        await context.SaveChangesAsync();
        
        return dinosaur;
    }

    public async Task<Dinosaur> AddMutationToDinosaur(int dinoCode, string mutationCode)
    {
        Dinosaur? dinosaur = await context.Dinosaurs.FirstOrDefaultAsync(d => d.DinoCode == dinoCode);
        if (dinosaur == null)
        {
            throw new NotFoundException("Dinosaur not found");
        }
        
        Nesting_Mutation? mutation = await context.NestingMutations.FirstOrDefaultAsync(db =>
            db.NestingId == dinosaur.NestId && db.MutationCode == mutationCode);
        if (mutation == null)
        {
            throw new NotFoundException("Mutation not found");
        }
        
        Dino_Mutation dinoMutation = new()
        {
            DinoCode = dinoCode,
            MutationCode = mutationCode,
            MutationName = mutation.MutationName
        };
        
        dinosaur.DinoMutations.Add(dinoMutation);
        
        await context.SaveChangesAsync();
        
        return dinosaur;
    }

    public async Task<Dinosaur> RemoveMutationFromDinosaur(int dinoCode, int mutationId)
    {
        Dinosaur? dinosaur = await context.Dinosaurs.FirstOrDefaultAsync(d => d.DinoCode == dinoCode);
        if (dinosaur == null)
        {
            throw new NotFoundException("Dinosaur not found");
        }
        
        Dino_Mutation? mutation = await context.DinoMutations.FirstOrDefaultAsync(db =>
            db.DinoCode == dinoCode && db.MutationCode == mutationId.ToString());
        if (mutation == null)
        {
            throw new NotFoundException("Mutation not found");
        }
        
        dinosaur.DinoMutations.Remove(mutation);
        
        await context.SaveChangesAsync();
        
        return dinosaur;
    }

    public async Task<Dinosaur> CreateChildrenForDinosaur(DinoChildrenDto childrenData)
    {
        Dinosaur? parent1 = await context.Dinosaurs
            .Include(d => d.DinoMutations)
            .Include(d => d.DinoBehaviours)
            .FirstOrDefaultAsync(d => d.DinoCode == childrenData.parent1Code);
        if (parent1 == null)
        {
            throw new NotFoundException("Parent 1 not found");
        }
        
        Dinosaur? parent2 = await context.Dinosaurs
            .Include(d => d.DinoMutations)
            .Include(d => d.DinoBehaviours)
            .FirstOrDefaultAsync(d => d.DinoCode == childrenData.parent2Code);
        if (parent2 == null)
        {
            throw new NotFoundException("Parent 2 not found");
        }

        Nesting_Lib? nesting = await context.Nestings.FirstOrDefaultAsync(n =>
            n.Parent1Code == childrenData.parent1Code && n.Parent2Code == childrenData.parent2Code);
        if (nesting == null)
        {
            throw new NotFoundException("Nest not found for these parents");
        }
        
        var species = await context.Species.FirstOrDefaultAsync(s => s.SpeciesId == childrenData.Species);
        if (species == null)
        {
            throw new NotFoundException("Species not found");
        }

        var parentRelationType = await context.RelationTypes.FirstOrDefaultAsync(rt => rt.RelationTypes == RelationTypes.Parent);
        
        var offspringRelationType = await context.RelationTypes.FirstOrDefaultAsync(rt => rt.RelationTypes == RelationTypes.Offspring);
        
        if (parentRelationType == null || offspringRelationType == null)
        {
            throw new Exception("Required relation types not found in database.");
        }

        var child = new Dinosaur()
        {
            UserId = parent1.UserId,
            DinoName = childrenData.Name,
            Color = childrenData.Color,
            SpeciesId = childrenData.Species,
            Gender = (Gender)childrenData.Gender,
            NestId = nesting.NestingId
        };

        // inherit mutations from parents with calculated chance
        
        var allMutations = await context.NestingMutations
            .Where(nm => nm.NestingId == nesting.NestingId)
            .ToListAsync();
        
        var parentMutationCodes = parent1.DinoMutations
            .Select(m => m.MutationCode)
            .Union(parent2.DinoMutations.Select(m => m.MutationCode))
            .Distinct();
        
        Random random = new();
        
        foreach (var mutationCode in parentMutationCodes)
        {
           Nesting_Mutation? mutationconfig = await context.NestingMutations
               .FirstOrDefaultAsync(ml => ml.MutationCode == mutationCode);
           
           if (mutationconfig == null)
           {
               double roll = random.NextDouble();
               if (roll <= mutationconfig.MutationChance)
               {
                   child.DinoMutations.Add(new Dino_Mutation { MutationCode = mutationCode });
               }
           }
        }

        // Inherit Behaviours
        IEnumerable<string> behaviourCodes = parent1.DinoBehaviours.Select(b => b.BehaviourCode)
            .Union(parent2.DinoBehaviours.Select(b => b.BehaviourCode))
            .Distinct();

        foreach (var behaviourCode in behaviourCodes)
        {
            child.DinoBehaviours.Add(new Dino_Behaviour { BehaviourCode = behaviourCode });
        }

        await context.Dinosaurs.AddAsync(child);
        await context.SaveChangesAsync(); // Save to get DinoCode for the child

        // Establish Relationships
        var relationships = new List<Dino_Relationship>
        {
            // Child's perspective: Parents
            new Dino_Relationship { 
                DinoCode = child.DinoCode, 
                TargetDinoCode = parent1.DinoCode, 
                RelationTypeId = parentRelationType.Id 
            },
            new Dino_Relationship
            {
                DinoCode = child.DinoCode, 
                TargetDinoCode = parent2.DinoCode, 
                RelationTypeId = parentRelationType.Id
            },
            
            // Parents' perspective: Offspring
            new Dino_Relationship
            {
                DinoCode = parent1.DinoCode, 
                TargetDinoCode = child.DinoCode, 
                RelationTypeId = offspringRelationType.Id
            },
            new Dino_Relationship
            {
                DinoCode = parent2.DinoCode, 
                TargetDinoCode = child.DinoCode, 
                RelationTypeId = offspringRelationType.Id
            }
        };

        await context.DinoRelationships.AddRangeAsync(relationships);
        await context.SaveChangesAsync();
        
        return child;
    }
}