import { useState, useEffect } from "react"
import DisplayProfileImageElement from "./DisplayProfileImageElement"
import UploadProfilePictureElement from "./UploadProfilePicElement";
import "../Styles/profilepage.css";
import { uploadProfilePicture } from "../Services/userServices";

export default function ProfileEditorElement({user}) {
    const[profilePicture, setProfilePicture] = useState(user.profilePicture);
    const[profilePictureFile, setProfilePictureFile] = useState(user.profilePicture);

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (profilePictureFile) {
          try {
            await uploadProfilePicture(user.userName, profilePictureFile);
            // You can also update the profilePicture in the state if needed
            // setProfilePicture(newProfilePicture);
            alert("Changes submitted successfully!");
          } catch (error) {
            console.error("Error submitting changes:", error);
          }
        } else {
          alert("No changes made.");
        }
      };

    return (
        <form className="profile-container">
             <DisplayProfileImageElement profilePicture={profilePicture} />
             <UploadProfilePictureElement setProfilePictureFile={setProfilePictureFile} setProfilePicture={setProfilePicture}/>
             <div className="user-info"><p>Username: {user.userName}</p></div>
             <div className="user-info"><p>Display name: {user.displayName}</p></div>
             <button className="edit-profile-button" onClick={handleSubmit}>Submit Changes</button>
        </form>
    );
}