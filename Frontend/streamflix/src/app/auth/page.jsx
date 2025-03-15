import Link from "next/link";
import Header from "../modules/Header"

export default function Auth(){
    return (
        <>
            <Header/>
            <form>
                <h1>StreamFlix</h1>
                <label>Log in to your account</label>
                <div>
                    <label>Email</label>
                    <input></input>
                </div>
                <div>
                    <label>Password</label>
                    <input></input>
                </div>
                <div>
                    <Link href="/">Forgot password.</Link>
                </div>
                <div>
                    <button>Log in</button>
                </div>
                <div>
                    Don't have an account? <Link href="/">Sign up.</Link>
                </div>
            </form>
        </>
    );
}