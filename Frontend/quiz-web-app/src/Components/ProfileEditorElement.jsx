import { useState, useEffect } from "react"
import DisplayProfileImageElement from "./DisplayProfileImageElement"
import UploadProfilePictureElement from "./UploadProfilePicElement";
import "../Styles/profilepage.css";
import { updateProfile } from "../Services/userServices";

export default function ProfileEditorElement({user}) {
    const[profilePicture, setProfilePicture] = useState(null);
    const[profilePictureFile, setProfilePictureFile] = useState(null);
    const[displayName, setDisplayName] = useState(null);

    const handleDisplayNameChange = (event) => {
      setDisplayName(event.target.value); // Update the state when the input changes
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (profilePictureFile || displayName!==user.displayName) {
          try {
            console.log(displayName);
            await updateProfile(user.userName, profilePictureFile, displayName);
            // You can also update the profilePicture in the state if needed
            // setProfilePicture(newProfilePicture);
            alert("Changes submitted successfully!");
            window.location.href="/";
          } catch (error) {
            console.error("Error submitting changes:", error);
          }
        } else {
          alert("No changes made.");
        }
      };

      //This converts the original pfp base64 data to jpeg because the updateProfile needs
      //an image or the backend needs it, this is a bandaid fix, will need to figure out a better solution
      function base64ToFile(base64Data, fileName, mimeType) {
        const byteCharacters = atob(base64Data);
        const byteNumbers = new Array(byteCharacters.length);
        for (let i = 0; i < byteCharacters.length; i++) {
          byteNumbers[i] = byteCharacters.charCodeAt(i);
        }
        const byteArray = new Uint8Array(byteNumbers);
        const blob = new Blob([byteArray], { type: mimeType });
        return new File([blob], fileName, { type: mimeType });
      }

      useEffect(()=>{
        if (user?.displayName) {
          setProfilePicture(user.profilePicture);
          if (user.profilePicture) {
            const file = base64ToFile(user.profilePicture, 'profile.jpg', 'image/jpeg');
            setProfilePictureFile(file);
          }
          setDisplayName(user.displayName);
        }
      },[user])

    return (
        <form className="profile-container">
            <div className="profilepic-container-container">
                <DisplayProfileImageElement profilePicture={profilePicture} />
             </div>
             <UploadProfilePictureElement setProfilePictureFile={setProfilePictureFile} setProfilePicture={setProfilePicture}/>
             <div className="user-info"><p>Username: {user?.userName}</p></div>
             <div className="user-info"> 
                <p>Display name: </p>
                <input className="edit-displayname" type="text" value={displayName} onChange={handleDisplayNameChange}></input>
              </div>
             <button className="edit-profile-button" onClick={handleSubmit}>Submit Changes</button>
        </form>
    );
}