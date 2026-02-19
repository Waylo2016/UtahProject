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
        
        if (dinosaur == null)
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

    public async Task<Dinosaur> PatchDinosaur(int dinoCode, JsonPatchDocument<DinosaurDto> patchDoc)
    {
        Dinosaur? dinosaur = await context.Dinosaurs.FirstOrDefaultAsync(d => d.DinoCode == dinoCode);
        
        if (dinosaur == null)
        {
            throw new NotFoundException("Dinosaur not found");
        }

        DinosaurDto dto = new()
        {
            DinoName = dinosaur.DinoName,
            Color = dinosaur.Color,
            SpeciesId = dinosaur.SpeciesId,
            Picture = dinosaur.Picture,
            gender = dinosaur.Gender

        };
        
        patchDoc.ApplyTo(dto);
        
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

    public async Task<Dinosaur> AddBehaviourToDinosaur(int dinoCode, int behaviourId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Dinosaur> RemoveBehaviourFromDinosaur(int dinoCode, int behaviourId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Dinosaur> AddNestToDinosaur(int dinoCode, int nestingId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Dinosaur> RemoveNestFromDinosaur(int dinoCode, int nestingId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Dinosaur> AddMutationToDinosaur(int dinoCode, int mutationId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Dinosaur> RemoveMutationFromDinosaur(int dinoCode, int mutationId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Dinosaur> CreateChildrenForDinosaur(DinoChildrenDto childrenData)
    {
        throw new NotImplementedException();
    }
}