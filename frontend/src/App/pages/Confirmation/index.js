import React from 'react';
import { useParams } from 'react-router-dom';
import useBooking from '../../../features/useBooking';

export default function Confirmation() {
    const { id } = useParams();
    const { data: confirmation, status } = useBooking(id);

    if (status === 'pending') {
        return <div>Loading...</div>;
    }

    return (
        <>
            <div>Confirmed</div>
            <pre>{JSON.stringify(confirmation, null, 4)}</pre>
        </>
    );
}
