import { useState, useEffect } from "react"
import { Link, useNavigate } from 'react-router-dom';
import "../Styles/register.css";
export default function RegisterElement(){

    const [email, setEmail] = useState(null);
    const [username, setUsername] = useState(null);
    const [password, setPassword] = useState(null);
    const [showSuccessMessage, setShowSuccessMessage] = useState(false);
    const [response, setResponse] = useState(null);

    const handleSubmit = () => {
        const data = {
            email: email,
            username: username,
            password: password,
            role: "User"
        }

        fetch('link here', {
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

    return(
        <div className='register-form'>
            {showSuccessMessage && (
                <>
                    {/* <SuccessfullElement message={"Successfully registered"}/> */}
                    <div className="register-successoverlay" />
                </>
            )}
            <div>
                <form>
                    <h2 className="register-text">Register</h2>
                    <div className="inputboxholder">
                        <div className='register-inputbox'>
                            <input type="email" required onChange={(e) => setEmail(e.target.value)} placeholder={""}></input>
                            <label for="">Email</label>
                        </div>
                        <div className='register-inputbox'>
                            <input type="text" required onChange={(e) => setUsername(e.target.value)} placeholder={""}/>
                            <label for="">Username</label>
                        </div>
                        <div className='register-inputbox'>
                            <input type="password" required onChange={(e) => setPassword(e.target.value)} placeholder={""}></input>
                            <label for="">Password</label>
                        </div>
                    </div>
                    <button type="form" className="register-button" onClick={handleSubmit}>Register</button>
                    <div className="login">
                        <p>
                            Already have an account? 
                            <Link to="/login">
                                <a> Login here!</a>
                            </Link>
                        </p>
                    </div>
                </form>
            </div>
        </div>
    )
}