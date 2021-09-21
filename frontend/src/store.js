import { configureStore } from '@reduxjs/toolkit'
import countries from './features/countries';

export default configureStore({
    reducer: {
        countries
    }
});