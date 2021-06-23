import React from 'react';

import SunIcon from '../../assets/sun.svg';
import MoonIcon from '../../assets/moon.svg';
import './Toggle.scss';

const Toggle = (props) => {
    return (
        <>
			<label className="switch" htmlFor="checkbox">
				<input type="checkbox" defaultChecked={props.darkMode} onChange={props.onClick} id="checkbox" />
				<div className="slider">
					<div className="scenary">
						<div className="moon"><img src={MoonIcon} alt="Dark Mode" /></div>
						<div className="sun"><img src={SunIcon} alt="Light Mode" /></div>
					</div>
				</div>

			</label>
        </>
    );
}

export default Toggle;