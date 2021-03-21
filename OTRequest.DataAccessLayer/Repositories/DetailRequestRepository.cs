using OTRequest.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTRequest.DataAccessLayer.Repositories
{
    public class DetailRequestRepository
    {
        private readonly OTRequestContext otContext;

        public DetailRequestRepository()
        {
            this.otContext = new OTRequestContext();
        }
        public IList ListDetailByRequestId(int id)
        {
            return this.otContext.DetailRequests.Where(x => x.RequestId == id).ToList();
        }
        public DetailRequest GetDetailRequest(int id)
        {
            return this.otContext.DetailRequests.FirstOrDefault(x => x.RequestId == id);
        }

        public void UpdateDetailRequest(DetailRequest detail)
        {
            this.otContext.Entry(detail).State = EntityState.Modified;
            this.otContext.SaveChanges();
        }

        public void AddDetailRequest(DetailRequest detail)
        {
            this.otContext.DetailRequests.Add(detail);
            this.otContext.SaveChanges();
        }

    }
}
