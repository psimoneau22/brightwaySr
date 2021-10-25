import axios from 'axios';

export async function submitBooking(booking) {
    const { data } = await axios.post('/api/booking', booking);
    return data;
}

export async function getBooking(id) {
    const { data } = await axios.get(`/api/booking/${id}`);
    return data;
}
