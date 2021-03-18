namespace OTRequest.DataAccessLayer.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OTRequest.Core.Models;
    using OTRequest.DataAccessLayer.Repositories.Interface;

    public class RequestRepository : IRequestRepository
    {
        private readonly OTRequestContext otContext;

        public RequestRepository()
        {
            this.otContext = new OTRequestContext();
        }

        public void CreateRequest(Request request)
        {
            this.otContext.Requests.Add(request);
            this.otContext.SaveChanges();
        }

        public void DeletedRequestById(int requestId)
        {
            var requestDeleted = FindRequestById(requestId);
            if(requestDeleted != null)
            {
                this.otContext.Requests.Attach(requestDeleted);
                this.otContext.Requests.Remove(requestDeleted);

                this.otContext.SaveChanges();
            }
        }

        public Request FindRequestById(int requestId)
        {
            return this.otContext.Requests.Find(requestId);
        }

        public IList<Request> FindRequestByManager(int managerId)
        {
            var listRequest = this.otContext.Requests.Where(r => r.Project.ManageId == managerId).ToList();
            return listRequest;
        }

        public IList<Request> FindRequestByProject(int idProject)
        {
            var listRequest = this.otContext.Requests.Where(r => r.Project.Id == idProject).ToList();
            return listRequest;
        }

        public IList<Request> FindRequestByUser(string userName)
        {
            var listRequest = this.otContext.Requests.Where(r => r.User == userName).ToList();
            return listRequest;
        }

        public void UpdateRequest(Request request)
        {
            this.otContext.Entry(request).State = System.Data.Entity.EntityState.Modified;
            this.otContext.SaveChanges();
        }

        public void Dipose()
        {
            this.otContext.Dispose();
        }

    }
}
