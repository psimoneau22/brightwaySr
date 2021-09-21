import React, { useEffect } from 'react'
import './index.scss';
import Destination from './Destination';
import UserName from './UserName';
import Email from './Email';
import Duration from './Duration';
import Submit from './Submit';

export default function Form() {

    console.log('rendForm');
    return (
        <form className="form">
            <Destination/>
            <UserName />
            <Email />
            <Duration />
            <Submit />
        </form>
    );
}