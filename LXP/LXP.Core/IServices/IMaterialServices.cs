using LXP.Common.ViewModels;
using LXP.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LXP.Core.IServices
{
    public interface IMaterialServices
    {
        object GetAllMaterialDetailsByTopic(string topicId);
        Task AddMaterial(MaterialViewModel material);
        Task<Material> GetMaterialByMaterialNameAndTopic(string materialName, string topicId);

    }
}
