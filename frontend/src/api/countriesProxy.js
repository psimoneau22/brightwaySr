import axios from 'axios';

export const getCountries = async () => {
    try {
        const response = await axios.get('/api/country');
        return response.data;
    } catch (error) {
        console.error(error);
    }
}