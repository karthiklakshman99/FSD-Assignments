import React from 'react';
import Adapter from 'enzyme-adapter-react-16';
import { configure } from 'enzyme';
import { render, screen } from '@testing-library/react';
import ConditionRender1 from '../Components/ConditionRender1';

configure({adapter: new Adapter()});

test('Conditional renders empty array', () => {
    const nameList = [];
    render(<ConditionRender1 names={nameList}/>);
    const element = screen.getByText(/No Contact Details Found!!/i);
    expect(element).toBeInTheDocument();
});