using System.Collections.Generic;
using System.Threading.Tasks;
using Utah_Project_API.Models;

namespace Utah_Project_API.Interfaces;

public interface INesting
{
    /// <summary>
    /// gets all nestings.
    /// </summary>
    /// <returns>a list of all Nesting</returns>
    Task<List<Nesting_Lib>> GetNestings();
    
    /// <summary>
    /// gets a specific nesting by its numerical id.
    /// </summary>
    /// <param name="nestingId">the numerical id of the nesting being retrieved</param>
    /// <returns>the nesting with the specified id</returns>
    Task<Nesting_Lib> GetNestingById(int nestingId);
    
    /// <summary>
    /// creates a new nesting.
    /// </summary>
    /// <param name="nestingData">data used to create a nesting</param>
    /// <returns>The created nesting.</returns>
    Task<Nesting_Lib> CreateNesting(NestingDto nestingData);

    /// <summary>
    /// updates an existing nesting.
    /// </summary>
    /// <param name="nestingId">numerical id of a nesting</param>
    /// <param name="nestingData">data used to update a nesting</param>
    /// <returns>the updated nesting</returns>
    Task<Nesting_Lib> UpdateNesting(int nestingId, NestingDto nestingData);
    
    /// <summary>
    /// deletes an existing nesting.
    /// </summary>
    /// <param name="nestingId">numerical id of a nesting</param>
    /// <returns>the deleted nesting</returns>
    Task<Nesting_Lib> DeleteNesting(int nestingId);
    
}