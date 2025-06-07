import React from 'react';
import Adapter from 'enzyme-adapter-react-16';
import { configure } from 'enzyme';
import { render, screen } from '@testing-library/react';
import ConditionRender1 from '../Components/ConditionRender1';

configure({adapter: new Adapter()});

test('Conditional renders Array', () => {
    const nameList = ["Alpha","Beta","Charlie"];
    render(<ConditionRender1 names={nameList}/>);
    const element = screen.getByText(/First Person:Alpha/i);
    expect(element).toBeInTheDocument();
});