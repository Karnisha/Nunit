using LXP.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LXP.Data.IRepository
{
    public interface IMaterialRepository
    {
        object GetAllMaterialDetailsByTopic(Topic topic);
        Task AddMaterial(Material material);
        Task<bool> AnyMaterialByMaterialNameAndTopic(string materialName,Topic topic);
        Task<Material> GetMaterialByMaterialNameAndTopic(string materialName, Topic topic);

    }
}
