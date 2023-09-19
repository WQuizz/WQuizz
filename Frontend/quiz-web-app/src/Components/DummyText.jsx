import {React, useEffect} from 'react'
import {useState} from "react";



export default function DummyText(){
    const [dummyText, setDummyText] = useState('');
    
    useEffect(() => {
        fetch('http://localhost:5015/api/dummy')
            .then(res => res.text())
            .then(r => setDummyText(r))
            .catch(err=>console.error(err))
    }, []);

    return(
        <>
            <div>
                {dummyText}
            </div>
        </>
    )
}