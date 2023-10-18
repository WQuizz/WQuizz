import { useState, useEffect } from "react"
import Cookies from 'universal-cookie';
import jwtDecode from "jwt-decode";

export default function UploadProfilePictureElement() {
    const [file, setFile] = useState(null);
    // const [userName, setUserName] = useState('admin');

    const handleFileChange = (e) => {
        const selectedFile = e.target.files[0];
        setFile(selectedFile);
    };
    const handleSubmit = async (e) => {
        e.preventDefault();
        const cookies = new Cookies();
        const jwtCookie = cookies.get('jwt_authorization');
        const decodedCookie = jwtDecode(jwtCookie);
        
        const username = decodedCookie["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
        console.log(username);
        if (!file) {
            console.log('No file selected');
            return;
        }

        const formData = new FormData();
        formData.append('userName', username); // Replace with the actual username
        formData.append('file', file); // 'file' is the key, and 'file' is the file you want to send

        try {
            const response = await fetch('http://localhost:9000/Profile/UploadProfilePicture', {
                method: 'POST',
                body: formData,
            });

            if (response.ok) {
                console.log('Profile picture uploaded and user profile updated.');
            } else {
                console.error('Upload failed:', response.status, response.statusText);
            }
        } catch (error) {
            console.error('Error:', error);
        }
    };
    const centeredElementStyle = {
        position: 'absolute',
        top: '100%',
        left: '50%',
        transform: 'translate(-50%, -50%)',
    };

    return (
        <div style={centeredElementStyle}>
            <input type="file" accept="image/*" onChange={handleFileChange} style={{ marginBottom: '10px' }}/>
            <button onClick={handleSubmit} style={{ backgroundColor: 'blue', color: 'white', padding: '10px 20px', borderRadius: '5px', cursor: 'pointer' }}>
                Upload Profile Picture
            </button>
        </div>
    );
}







