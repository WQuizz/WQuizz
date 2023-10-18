import { Link } from 'react-router-dom';
import "../Styles/register.css";
export default function RegisterElement({setEmail, setUsername, setPassword, handleSubmit, errorMessage}){
    return(
        <div className='register-form'>
            <div>
                <form onSubmit={handleSubmit}>
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
                    <button type="form" className="register-button">Register</button>
                    <div className="invalid-register-message">{errorMessage}</div>
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