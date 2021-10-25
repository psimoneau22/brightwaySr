import axios from 'axios';

// eslint-disable-next-line import/prefer-default-export
export async function getCountries() {
    try {
        const response = await axios.get('/api/country');
        return response.data;
    } catch (error) {
        // todo
        return null;
    }
}
