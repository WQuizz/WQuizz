import { useState, useEffect } from "react"
import { uploadProfilePicture } from "../Services/userServices";
import "../Styles/profilepage.css";

export default function UploadProfilePictureElement({setProfilePictureFile, setProfilePicture}) {
 
    const handleFileChange = async (e) => {
        //const dataUrl = `data:image/jpeg;base64,${profilePicture}`;
        const selectedFile = e.target.files[0];
        if (!selectedFile) {
            console.log('No file selected');
            return;
          }
        setProfilePictureFile(selectedFile);
        const reader = new FileReader();
        reader.onload = (event) => {
            const base64String = event.target.result.split(',')[1];
            console.log(base64String);
            setProfilePicture(base64String);
        };

        reader.readAsDataURL(selectedFile);
        // await uploadProfilePicture(user.userName, selectedFile);
    };
    // const handleSubmit = async (e) => {
    //     e.preventDefault();


    //     if (!file) {
    //         console.log('No file selected');
    //         return;
    //       }
    //     await uploadProfilePicture(userName, file);
    // };


    return (
        <div className="upload-picture-container">
            <input type="file" accept="image/*" onChange={handleFileChange}/>
            {/* <button onClick={handleSubmit}>
                Upload Picture
            </button> */}
        </div>
    );
}