import styles from './AdminLayout.module.css';
import Link from "next/link";

export default function AdminLayout({children}) {
    return(
        <>
            <div className={styles.sidebar}>
                <div>
                    <h1 className="">StreamFlix</h1>
                </div>
                <div >
                    <h4>Тут пользователь будет</h4>
                </div>
                <div>
                    <Link href="/admin/parsers">Parsers</Link>
                </div>
                <div className={styles.sidebar_exit_button_container}>
                    <Link href="/">Back to StreamFlix</Link>
                </div>
            </div>
            <div className={styles.admin_layout_body_container}>
                {children}
            </div>
        </>
    );
}