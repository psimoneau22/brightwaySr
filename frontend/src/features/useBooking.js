import { useEffect, useState } from 'react';
import { getBooking } from '../api/bookingProxy';

export default function useBooking(id) {
    const [booking, setBooking] = useState({
        data: null,
        status: 'idle',
        error: null,
    });

    useEffect(async () => {
        setBooking({
            data: null,
            status: 'pending',
            error: null,
        });

        try {
            const response = await getBooking(id);
            setBooking({
                data: response,
                status: 'complete',
            });
        } catch (ex) {
            setBooking({
                data: null,
                status: 'errored',
                error: {
                    message: 'Error retrieving booking',
                    exception: ex,
                },
            });
        }
    }, [id]);

    return booking;
}
