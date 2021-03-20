namespace OTRequest.DataAccessLayer.Repositories.Interface
{
    using OTRequest.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    interface IRequestRepository
    {
        /// <summary>
        /// Create a request.
        /// </summary>
        /// <param name="request"></param>
        void CreateRequest(Request request);

        /// <summary>
        /// Update a request.
        /// </summary>
        /// <param name="request"></param>
        void UpdateRequest(Request request);

        /// <summary>
        /// Find list request with projectId.
        /// </summary>
        /// <param name="idProject"></param>
        /// <returns></returns>
        IList<Request> FindRequestByProject(int idProject);

        /// <summary>
        /// Find list request with managerId.
        /// </summary>
        /// <param name="managerId"></param>
        /// <returns></returns>
        IList<Request> FindRequestByManager(string managerId);

        /// <summary>
        /// Find list request with userId.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IList<Request> FindRequestByUser(string userName);
        void DeletedRequestById(int requestId);

        /// <summary>
        /// Find requst by Id.
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        Request FindRequestById(int requestId);

        void Dipose();
    }
}
