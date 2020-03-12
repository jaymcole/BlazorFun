using Microsoft.AspNetCore.Mvc;
using MyShuttle.Data;
using MyShuttle.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyShuttle.API.Controllers
{


    [NoCacheFilter]
    public class DriversController: Controller
    {
        IDriverRepository _driverRepository;
        private const int DefaultCarrierID = 0;
        public DriversController(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }
        public async Task<Driver> Get(int id)
        {
            return await _driverRepository.GetAsync(DefaultCarrierID, id);
        }

        [System.Web.Mvc.ActionName("search")]
        public async Task<IEnumerable<Driver>> Get(string filter, int pageSize, int pageCount)
        {
            if (String.IsNullOrEmpty(filter))
                filter = string.Empty;

            return await _driverRepository.GetDriversAsync(DefaultCarrierID, filter, pageSize, pageCount);
        }

        [System.Web.Mvc.ActionName("filter")]
        public async Task<IEnumerable<Driver>> GetDriversFilter()
        {
            return await _driverRepository.GetDriversFilterAsync(DefaultCarrierID);
        }

        [System.Web.Mvc.ActionName("count")]
        public async Task<int> GetCount(string filter)
        {
            if (String.IsNullOrEmpty(filter))
                filter = string.Empty;

            return await _driverRepository.GetCountAsync(DefaultCarrierID, filter);
        }

        [System.Web.Mvc.HttpPost]
        public async Task<int> Post([FromBody]Driver driver)
        {
            driver.CarrierId = DefaultCarrierID;
            return await _driverRepository.AddAsync(driver);
        }

        [System.Web.Mvc.HttpPut]
        public async Task Put([FromBody]Driver driver)
        {
            driver.CarrierId = DefaultCarrierID;
            await _driverRepository.UpdateAsync(driver);
        }

        [System.Web.Mvc.HttpDelete]
        public async Task Delete(int id)
        {
            await _driverRepository.DeleteAsync(id);
        }




    }
}
