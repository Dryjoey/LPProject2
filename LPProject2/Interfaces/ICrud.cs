using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ICrud<T>
    {
        List<T> GetObjects();
        void AddEntity(T Entity);
        void UpdateEntity(int EntityId);
        void DeleteEntity(int EntityId);
    }
    
}
