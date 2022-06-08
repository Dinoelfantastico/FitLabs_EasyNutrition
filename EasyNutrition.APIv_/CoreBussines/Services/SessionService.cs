using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Repositories;
using EasyNutrition.APIv_.CoreBussines.Domain.Services;
using EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IUnitOfwork _unitOfWork;

        public SessionService(ISessionRepository sessionRepository, IUnitOfwork unitOfWork)
        {
            _sessionRepository = sessionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Session>> ListAsync()
        {
            return await _sessionRepository.LisAsync();
        }


        public async Task<IEnumerable<Session>> ListByUserIdAsync(int userId)
        {
            return await _sessionRepository.ListByUserIdAsync(userId);
        }

        public async Task<SessionResponce> GetByIdAsync(int id)
        {
            var existingSession = await _sessionRepository.FindById(id);

            if (existingSession == null)
                return new SessionResponce("Session not found");
            return new SessionResponce(existingSession);
        }


        public async Task<SessionResponce> SaveAsync(Session session)
        {
            try
            {
                await _sessionRepository.AddAsync(session);
                await _unitOfWork.CompleteAsync();

                return new SessionResponce(session);
            }
            catch (Exception ex)
            {
                return new SessionResponce($"An error ocurred while saving session: {ex.Message}");
            }
        }

        public async Task<SessionResponce> UpdateAsync(int userId, Session session)
        {
            var existingSession = await _sessionRepository.FindById(userId);
            if (existingSession == null)
                return new SessionResponce("Session not found");

            existingSession.Link = session.Link;

            try
            {
                _sessionRepository.Update(existingSession);
                await _unitOfWork.CompleteAsync();

                return new SessionResponce(existingSession);
            }
            catch (Exception ex)
            {
                return new SessionResponce($"An error ocurred while updating Session: {ex.Message}");
            }
        }



        public async Task<SessionResponce> DeleteAsync(int id)
        {
            var existingSession = await _sessionRepository.FindById(id);

            if (existingSession == null)
                return new SessionResponce("Session not found");

            try
            {
                _sessionRepository.Remove(existingSession);
                await _unitOfWork.CompleteAsync();

                return new SessionResponce(existingSession);
            }
            catch (Exception ex)
            {
                return new SessionResponce($"An error ocurred while deleting session: {ex.Message}");
            }
        }
        
    }
}
