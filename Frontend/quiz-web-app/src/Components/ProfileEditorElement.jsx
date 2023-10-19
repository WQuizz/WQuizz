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
            await updateProfile(user.userName, profilePictureFile, displayName);
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

      useEffect(()=>{
        if (user?.displayName) {
          setProfilePicture(user.profilePicture);
          setProfilePictureFile(user.profilePicture?user.profilePicture:null);
          setDisplayName(user.displayName);
        }
      },[user])

    return (
        <form className="profile-container">
             <DisplayProfileImageElement profilePicture={profilePicture} />
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