using HealthCareBackend.DTOs;
using HealthCareBackend.Repositories;

namespace HealthCareBackend.Services
{
    public class DoctorTodaysAppointmentService
    {
        private readonly DoctorTodaysAppointmentRepository _doctorTodaysAppointmentRepository;

        public DoctorTodaysAppointmentService(DoctorTodaysAppointmentRepository doctorTodaysAppointmentRepository)
        {
            _doctorTodaysAppointmentRepository = doctorTodaysAppointmentRepository;
        }

        public List<DoctorTodaysAppointmentDTO> GetTodaysDoctorAppointments(int doctorId)
        {
            return _doctorTodaysAppointmentRepository.GetTodaysDoctorAppointments(doctorId);
        }
    }
}
