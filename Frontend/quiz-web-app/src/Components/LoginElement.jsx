import { useState, useEffect } from "react"
import "../Styles/login.css";
import { Link, useNavigate } from 'react-router-dom';

export default function LoginElement({cookies, setUser}){
    //console.log(user);
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [response, setResponse] = useState(null);
    const navigate = useNavigate();
    


    const handleSubmit = () => {
        const data = {
            email: email,
            password: password,
        }
        
        fetch('http://localhost:8082/Auth/Loginpaste link here', {
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
            })
            .catch(err=>console.error(err))
    };

    //Once we get a response we will need to figure out how to store the token and how to handle login

    return(
        <div className='login-form'>
            <div>
                <form>
                    <h2 className="login-text">Login</h2>
                    <div className="login-inputboxholder">
                        <div className="login-inputbox">
                            <input type="text" required onChange={(e) => setEmail(e.target.value)} placeholder=""></input>
                            <label for="emailInput">Email</label>
                        </div>
                        <div className="login-inputbox">
                            <input type="password" required onChange={(e) => setPassword(e.target.value)} placeholder=""></input>
                            <label for="">Password</label>
                        </div>
                    </div>
                    <div className="forget">
                            <a href="#"> Forgot Password?</a>
                    </div>
                    <button type="form" className="login-button" onClick={handleSubmit}>Login</button>
                    <div className="register">
                        <p>
                            Don't have an account? 
                            <Link to="/registration">
                                <a> Register here!</a>
                            </Link>
                        </p>
                    </div>
                </form>
            </div>
        </div>
    )
}