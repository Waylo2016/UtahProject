using System.Collections.Generic;
using System.Threading.Tasks;
using Utah_Project_API.Models;

namespace Utah_Project_API.Interfaces;

public interface IBehaviour
{
    /// <summary>
    /// Gets all behaviours.
    /// </summary>
    /// <returns>a list of behaviours</returns>
    Task<List<Behaviour_Lib>> GetBehaviours();
    
    /// <summary>
    /// Gets a specific behaviour by its numerical id.
    /// </summary>
    /// <param name="behaviourId">the numerical id of the behaviour being retrieved</param>
    /// <returns>the behaviour with the specified id</returns>
    Task<Behaviour_Lib> GetBehaviourById(int behaviourId);    
    
    /// <summary>
    /// Creates a new behaviour.
    /// </summary>
    /// <param name="behaviourData">data used to create a behaviour</param>
    /// <returns>The created behaviour.</returns>
    Task<Behaviour_Lib> CreateBehaviour(BehaviourDto behaviourData);
    
    /// <summary>
    /// Updates an existing behaviour.
    /// </summary>
    /// <param name="behaviourId">numerical id of a behaviour</param>
    /// <param name="behaviourData">data used to update a behaviour</param>
    /// <returns>the updated behaviour</returns>
    Task<Behaviour_Lib> UpdateBehaviour(int behaviourId, BehaviourDto behaviourData);
    
    /// <summary>
    /// Deletes an existing behaviour.
    /// </summary>
    /// <param name="behaviourId">numerical id of a behaviour</param>
    /// <returns>the deleted behaviour</returns>
    Task<Behaviour_Lib> DeleteBehaviour(int behaviourId);
}