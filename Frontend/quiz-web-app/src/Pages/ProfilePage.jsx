import ProfileElement from "../Components/ProfileElement";
import { useParams } from 'react-router-dom';
import { useEffect, useState } from "react";
import { fetchUserProfile } from "../Services/userServices";
import "../Styles/profilepage.css";

export default function ProfilePage({userName}) {
    const { profileName } = useParams();
    const [userProfile, setUserProfile] = useState(null);
    const [isYourProfile, setIsYourProfile] = useState(false);

    useEffect(() => {
        async function getUserProfile() {
            const newUser = await fetchUserProfile(profileName);
            setIsYourProfile(userName === profileName);
            if (isYourProfile) {
                setUserProfile(newUser);
            } else {
                try {
                    setUserProfile(newUser);
                } catch (error) {
                    console.error('Error fetching user profile:', error);
                }
            }
        }
        getUserProfile();
    }, [profileName]);

    useEffect(() => { }, [userProfile]);

    return (
        <div className="profilepage">
            {userProfile?.userName && <ProfileElement user={userProfile} canEdit={isYourProfile}/>}
        </div>
    )
}