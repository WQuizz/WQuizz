import {React, useEffect} from 'react'
import {useState} from "react";
import ourLogo from '../Images/ourlogo.png';
import '../Styles/homepage.css';


export default function DummyText(){
    const [dummyText, setDummyText] = useState('');
    
    useEffect(() => {
        fetch('http://localhost:9000/api/dummy')
            .then(res => res.text())
            .then(r => setDummyText(r))
            .catch(err=>console.error(err))
    }, []);

    return(
        <>
        <div>
            <img src={ourLogo} className='homeImage'></img> 
        </div>
        <div className='dummy'>
           
        </div>
        
        </>
    )
}