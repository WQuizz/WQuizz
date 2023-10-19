import ProfileEditorElement from '../Components/ProfileEditorElement';
import { useParams } from 'react-router-dom';
import { fetchUserProfile } from "../Services/userServices";
import { useEffect, useState } from "react";

export default function EditProfilePage({userName}) {
    const [validateProfile, setValidateProfile] = useState(false);
    const [userProfile, setUserProfile] = useState(null);
    const { profileName } = useParams();
    async function getUserProfile() {
        
        if (profileName === userName) {
            const newUser = await fetchUserProfile(profileName);
            setValidateProfile(true);
            console.log(newUser);
            setUserProfile(newUser);
        }
    }
    useEffect(() => {
      
        getUserProfile();
    }, [profileName]);



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