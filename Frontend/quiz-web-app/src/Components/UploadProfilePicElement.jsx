import { useState, useEffect } from "react"
import { uploadProfilePicture } from "../Services/userServices";

export default function UploadProfilePictureElement({userName}) {
    const [file, setFile] = useState(null);

    const handleFileChange = (e) => {
        const selectedFile = e.target.files[0];
        setFile(selectedFile);
    };
    const handleSubmit = async (e) => {
        e.preventDefault();


        if (!file) {
            console.log('No file selected');
            return;
          }
          await uploadProfilePicture(userName, file);
    };
    const centeredElementStyle = {
        position: 'absolute',
        top: '50%',
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