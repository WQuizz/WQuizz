import { useState, useEffect } from "react"
import RegisterElement from "../Components/RegisterElement";
import SuccessfullElement from "../Components/SuccessfullElement";
import { useNavigate } from 'react-router-dom';
import "../Styles/register.css";
import { AuthUrl } from "../Files/APIUrl";

export default function RegisterPage({loggedIn}){
    const [email, setEmail] = useState(null);
    const [username, setUsername] = useState(null);
    const [password, setPassword] = useState(null);
    const [showSuccessMessage, setShowSuccessMessage] = useState(false);
    const [response, setResponse] = useState(null);
    const [errorMessage, setErrorMessage] = useState(null);

    const navigate = useNavigate();

    const handleSubmit = (e) => {
        e.preventDefault();
        const data = {
            email: email,
            username: username,
            password: password,
        }

        fetch(AuthUrl + 'Register', {
        method: 'POST',
        mode: 'cors',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data)
        })
            .then(res => res.json())
            .then(r => {setResponse(r)})
            .catch(err=>console.error(err))
    };

    useEffect(()=>{
        console.log(response);
        if ((response && 'DuplicateEmail' in response)|| (response && 'DuplicateUserName' in response)) {
            setErrorMessage('Username or e-mail is already in use'); 
        }
        if(response && 'email' in response){
            setShowSuccessMessage(true);
            setTimeout(() => {
                setShowSuccessMessage(false);
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
            <div className="register-page-element-container">
                {showSuccessMessage && (
                <>
                    <SuccessfullElement message={"Successfully registered"}/>
                    <div className="register-successoverlay" />
                </>
                )}
                <RegisterElement 
                    setEmail={setEmail} 
                    setUsername={setUsername} 
                    setPassword ={setPassword} 
                    handleSubmit={handleSubmit}
                    errorMessage={errorMessage}
                    ></RegisterElement>
            </div>
    
        )
    }