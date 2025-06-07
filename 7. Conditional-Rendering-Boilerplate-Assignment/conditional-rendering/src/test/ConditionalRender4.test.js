import React from 'react';
import Adapter from 'enzyme-adapter-react-16';
import { configure } from 'enzyme';
import { render, screen } from '@testing-library/react';
import ConditionRender2 from '../Components/ConditionRender2';

configure({adapter: new Adapter()});

test('Conditional renders empty array', () => {
    const participantsLoggedIn = true;
    render(<ConditionRender2 loggedIn={participantsLoggedIn}/>);
    const element = screen.getByText(/Hello Alpha!!/i);
    expect(element).toBeInTheDocument();
});