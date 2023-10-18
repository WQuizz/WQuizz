import ProfileEditorElement from '../Components/ProfileEditorElement';
import { useParams } from 'react-router-dom';
import { useEffect, useState } from "react";

export default function EditProfilePage({user}) {
    const [validateProfile, setValidateProfile] = useState(false);
    const { userName } = useParams();

    useEffect(() => {
        // You can access the userName from the URL here
        async function getUserProfile() {
            setValidateProfile(userName === user?.userName);
        }

        getUserProfile();
    }, [userName, user]);

    return (
        <div className="profilepage">
            {validateProfile ? 
            (
                <ProfileEditorElement user={user}/>
            ) : (
                <div style={{ position: 'absolute', top: '50%', left: '50%', transform: 'translate(-50%, -50%)', color:"white" }}>You have no access to this profile 3:</div>
            )}
        </div>
    )
}