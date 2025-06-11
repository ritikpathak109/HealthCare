using HealthCareBackend.DTOs;
using HealthCareBackend.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HealthCareBackend.Repositories
{
    public class ConsultationRepository
    {
        private readonly MyDbContext _context;

        public ConsultationRepository(MyDbContext context)
        {
            _context = context;

        }
        public void AddConsultation(ConsultationDTO consultationDTO)
        {

            var parameters = new[]
            {
            new SqlParameter("@AppointmentId", consultationDTO.AppointmentId),
            new SqlParameter("@DoctorId", consultationDTO.DoctorId),
            new SqlParameter("@PatientId", consultationDTO.PatientId),
            new SqlParameter("@SubjectiveNotes", consultationDTO.SubjectiveNotes ),
            new SqlParameter("@BloodPressure", consultationDTO.BloodPressure ),
            new SqlParameter("@Pulse", consultationDTO.Pulse ),
            new SqlParameter("@Temperature", consultationDTO.Temperature ),
            new SqlParameter("@ObjectiveNotes", consultationDTO.ObjectiveNotes ),
            new SqlParameter("@Assessment", consultationDTO.Assessment ),
            new SqlParameter("@GeneralAdvice", consultationDTO.GeneralAdvice ),
        };

            _context.USP_AddConsultationDetails.FromSqlRaw("EXEC USP_AddConsultationDetails  @AppointmentId, @DoctorId, @PatientId, @SubjectiveNotes, @BloodPressure, @Pulse, @Temperature, @ObjectiveNotes, @Assessment, @GeneralAdvice", parameters);
        }
       


    }
}
