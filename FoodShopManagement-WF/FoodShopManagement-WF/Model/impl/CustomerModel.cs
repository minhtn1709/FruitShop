﻿using DTO;
using FoodShopManagement_WF.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopManagement_WF.Model.impl
{
    public class CustomerModel : ICustomerModel
    {
        public List<TblCustomerDTO> loadCustomers()
        {
            try
            {
                HttpResponseMessage responseMessage = ApiConnection.loadGetJsonObject("customer/load-customer", Program.TokenGlobal);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var resultFromApi = responseMessage.Content.ReadAsStringAsync();
                    List<TblCustomerDTO> listResult = JsonConvert.DeserializeObject<List<TblCustomerDTO>>(resultFromApi.Result);
                    return listResult;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }

        public bool addCustomer(TblCustomerDTO dto)
        {
            HttpResponseMessage responseMessage = ApiConnection.loadPostJsonObject("customer/add-customer", dto, Program.TokenGlobal);
            if (responseMessage.IsSuccessStatusCode)
            {
                var resultFromApi = responseMessage.Content.ReadAsStringAsync();
                bool isSuccess = JsonConvert.DeserializeObject<bool>(resultFromApi.Result);
                return isSuccess;
            }
            return false;
        }

        public bool updateCustomer(TblCustomerDTO dto)
        {
            HttpResponseMessage responseMessage = ApiConnection.loadPutJsonObject("customer/update-customer", dto, Program.TokenGlobal);
            if (responseMessage.IsSuccessStatusCode)
            {
                var resultFromApi = responseMessage.Content.ReadAsStringAsync();
                bool isSuccess = JsonConvert.DeserializeObject<bool>(resultFromApi.Result);
                return isSuccess;
            }
            return false;
        }
    }
}