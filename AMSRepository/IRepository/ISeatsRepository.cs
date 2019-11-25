using System.Collections.Generic;
using AMSRepository.Models;

namespace AMSRepository.Repository
{
    public interface ISeatsRepository
    {
        Seats CreateSeat(Seats seats);
        List<Seats> GetSeats();
        Seats GetSeatsByID(int seatsID);
        Seats UpdateSeat(Seats seats);
    }
}