using LXP.Common.Entities;
using LXP.Common.ViewModels;
using LXP.Core.IServices;
using LXP.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LXP.Core.Services
{
    public class MaterialServices : IMaterialServices
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly ICourseTopicRepository _courseTopicRepository;
        public MaterialServices() { }
        public async Task AddMaterial(MaterialViewModel material)
        {
            //Topic topic = _courseTopicRepository.GetTopicByTopicId();
            //bool isMaterialExists = await _materialRepository.AnyMaterialByMaterialNameAndTopic();
            throw new NotImplementedException();
        }

        public object GetAllMaterialDetailsByTopic(string topicId)
        {
            throw new NotImplementedException();
        }

        public Task<Material> GetMaterialByMaterialNameAndTopic(string materialName, string topicId)
        {
            throw new NotImplementedException();
        }
    }
}
