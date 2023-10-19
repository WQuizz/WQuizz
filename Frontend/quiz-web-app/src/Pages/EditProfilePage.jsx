import ProfileEditorElement from '../Components/ProfileEditorElement';
import { useParams } from 'react-router-dom';
import { fetchUserProfile } from "../Services/userServices";
import { useEffect, useState } from "react";

export default function EditProfilePage() {
    const [validateProfile, setValidateProfile] = useState(false);
    const [userProfile, setUserProfile] = useState(null);
    const { userName } = useParams();
    async function getUserProfile() {
        const newUser = await fetchUserProfile(userName);
        if (userName === newUser?.userName) {
            setValidateProfile(true);
            
            console.log(newUser);
            setUserProfile(newUser);
        }
    }
    useEffect(() => {
      
        getUserProfile();
    }, [userName]);



    return (
        <div className="profilepage">
            {validateProfile ? 
            (
                <ProfileEditorElement user={userProfile}/>
            ) : (
                <div style={{ position: 'absolute', top: '50%', left: '50%', transform: 'translate(-50%, -50%)', color:"white" }}>You have no access to this profile 3:</div>
            )}
        </div>
    )
}