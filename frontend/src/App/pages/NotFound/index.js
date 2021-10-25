import React from 'react';
import './index.scss';

export default function NotFound() {
    return (
        <div className="not-found">
            <div className="not-found__code">404</div>
            <div className="not-found__title">Not Found</div>
            <div className="not-found__message">The resource requested could not be found</div>
        </div>
    );
}
