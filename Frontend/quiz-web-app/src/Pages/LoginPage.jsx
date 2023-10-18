import LoginElement from "../Components/LoginElement";
import Cookies from "universal-cookie";
import "../Styles/login.css";
import { useEffect, useState } from "react";
import SuccessfullElement from "../Components/SuccessfullElement";
import { useNavigate } from 'react-router-dom';

export default function LoginPage({setLoggedIn, loggedIn}){
    const [email, setEmail] = useState(null);
    const [password, setPassword] = useState(null);
    const [response, setResponse] = useState(null);
    const [errorMessage, setErrorMessage] = useState(null);
    const [showSuccessMessage, setShowSuccessMessage] = useState(false);

    
    const navigate = useNavigate();

    const handleSubmit = (e) => {
        e.preventDefault();
        const data = {
            Email: email,
            Password: password,
        }
        
        fetch('http://localhost:9000/Auth/Login', {
        method: 'POST',
        mode: 'cors',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data)
        })
            .then(res => res.json())
            .then(r => {
                setResponse(r);
                setErrorMessage(null)
            })
            .catch(err=>console.error(err))
    };

    useEffect(()=>{
        const cookies = new Cookies();
        if (response && 'Bad credentials' in response) {
            setErrorMessage('Invalid email or password');
        }
        if (response && 'token' in response) {
            cookies.set("jwt_authorization", response.token);
            setShowSuccessMessage(true);
            setTimeout(() => {
                setShowSuccessMessage(false);
                setLoggedIn(true);
                navigate("/");
            }, 3000);
        }
    },[response, navigate])

    useEffect(() => {
        if (loggedIn) {
          navigate('/');
        }
      }, [loggedIn, navigate]);

    return(
            <div className="login-page-element-container">
                {showSuccessMessage && (
                <>
                    <SuccessfullElement message={"Successfully logged in!"}/>
                    <div className="login-successoverlay" />
                </>
                )}
                <LoginElement setEmail={setEmail} setPassword={setPassword} handleSubmit={handleSubmit} errorMessage={errorMessage}></LoginElement>
            </div>
        )
    }