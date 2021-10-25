import { useState, useEffect } from 'react';
import axios from 'axios';

export default function useCountries() {
    const [countries, setCountries] = useState({
        status: 'idle',
        data: [],
        error: null,
    });

    useEffect(async () => {
        if (countries.status === 'complete') return;

        setCountries({
            status: 'pending',
            data: [],
            error: null,
        });

        try {
            const response = await axios.get('/api/country');
            setCountries({
                status: 'complete',
                data: response.data,
                error: null,
            });
        } catch (ex) {
            setCountries({
                status: 'errored',
                data: [],
                error: {
                    message: 'Error retrieving countires',
                    exception: ex,
                },
            });
        }
    }, []);

    return countries;
}
