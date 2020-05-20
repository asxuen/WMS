﻿using Coldairarrow.Business.PB;
using Coldairarrow.Entity.PB;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.PB
{
    [Route("/PB/[controller]/[action]")]
    public class PB_StorageController : BaseApiController
    {
        #region DI

        public PB_StorageController(IPB_StorageBusiness PB_StorageBus)
        {
            _PB_StorageBus = PB_StorageBus;
        }

        IPB_StorageBusiness _PB_StorageBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<PB_Storage>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _PB_StorageBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<PB_Storage> GetTheData(IdInputDTO input)
        {
            return await _PB_StorageBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(PB_Storage data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _PB_StorageBus.AddDataAsync(data);
            }
            else
            {
                await _PB_StorageBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _PB_StorageBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}