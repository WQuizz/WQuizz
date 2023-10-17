import { useState, useEffect } from "react"
import "../Styles/login.css";
import { Link } from 'react-router-dom';

export default function LoginElement({setEmail, setPassword, handleSubmit, errorMessage}){
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
                    <button type="button" className="login-button" onClick={handleSubmit}>Login</button>
                    {errorMessage && <div className="invalid-login-message">{errorMessage}</div>}
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