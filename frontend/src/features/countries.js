import { createSlice, createAsyncThunk } from '@reduxjs/toolkit'
import { getCountries } from '../api/countriesProxy'

export const fetchCountries = createAsyncThunk('countries/load', getCountries)

const countriesSlice = createSlice({
    name: 'countries',
    initialState: {
        status: 'idle',
        data: [],
        error: null,
        value: 0
    },
    reducers: {
        increment(state) {
            state.value++
        }
    },
    extraReducers: builder => {
        builder
          .addCase(fetchCountries.pending, state => {
                state.status = 'pending'
          })
          .addCase(fetchCountries.fulfilled, (state, action) => {
                state.status = 'succeeded'
                state.data = state.data.concat(action.payload)
          })
          .addCase(fetchCountries.rejected, (state, action) => {
                state.status = 'failed'
                state.error = action.error.message
          })
    }
})

export default countriesSlice.reducer;