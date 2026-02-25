"use client";

import s from "./Header.module.css";
import Link from "next/link";

export default function Header() {

    return (
        <header>
            <nav className={`fixed-top ${s.nav}`} >
                <div className={`d-flex justify-content-between align-items-center mx-auto d-inline-block ${s.headerBar}`}>
                    <Link href="/" className={s.link}>Waylo.tech</Link>
                    <div className={`d-flex ${s.links}`}>
                        <Link href="/about" className={`${s.linkInfo}`}>About</Link>
                        <Link href="/projects" className={`${s.linkInfo}`}>Projects</Link>
                        <Link href="/contact" className={`${s.linkInfo}`}>Contact</Link>
                    </div>
                </div>
            </nav>
        </header>
    );
}