import Link from "next/link";

export default function Auth(){
    return (
        <>
            <form>
                <h1>StreamFlix</h1>
                <lable>Login to your account</lable>
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