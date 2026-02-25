"use client";

import s from "./Header.module.css";
import Link from "next/link";

export default function Header() {

    return (
        <header>
            <nav className={}>
                <div className={` ${s.nav_website}`}>
                    <Link href="/" className={s.link}>Waylo.tech</Link>
                </div>
            </nav>
        </header>
    );
}