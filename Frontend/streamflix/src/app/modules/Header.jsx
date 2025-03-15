import Link from "next/link";

export default function Header(){
    return(
        <header>
            <div className="">
                <h1>StreamFlix</h1>
            </div>
            <div className="">
                <Link href="/">Home</Link>
                <Link href="/">Genres</Link>
                <Link href="/">Releases</Link>
            </div>
            <div className="">
                <Link href="/">LogIn</Link>
            </div>
        </header>
    )
}