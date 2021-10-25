import { configureStore } from '@reduxjs/toolkit';

export default configureStore({
    reducer: {
        test: state => (
            state === undefined
                ? { }
                : state
        ),
    },
});
